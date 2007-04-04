using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using System.Drawing.Imaging;

namespace Aga.Controls.Tree
{
	[TypeConverter(typeof(TreeColumn.TreeColumnConverter)), DesignTimeVisible(false), ToolboxItem(false)]
	public class TreeColumn : Component
	{
		private class TreeColumnConverter : ComponentConverter
		{
			public TreeColumnConverter()
				: base(typeof(TreeColumn))
			{
			}

			public override bool GetPropertiesSupported(ITypeDescriptorContext context)
			{
				return false;
			}
		}

		private const int HeaderLeftMargin = 5;
        private const int HeaderRightMargin = 4;   
		private const int SortOrderMarkMargin = 4;
		//private const int SortOrderMarkWidth = 7;

        private TextFormatFlags _headerFlags;
        private TextFormatFlags _baseHeaderFlags = TextFormatFlags.NoPadding | 
                                                   TextFormatFlags.EndEllipsis | 
                                                   TextFormatFlags.VerticalCenter;

		#region Properties

        #region internal Properties

        private TreeColumn _hiddenColumn;
        internal TreeColumn HiddenColumn
        {
            get { return _hiddenColumn; }
            set { _hiddenColumn = value; }
        }

        #endregion

        private TreeColumnCollection _owner;
		internal TreeColumnCollection Owner
		{
			get { return _owner; }
			set { _owner = value; }
		}

		[Browsable(false)]
		public int Index
		{
			get 
			{
				if (Owner != null)
					return Owner.IndexOf(this);
				else
					return -1;
			}
		}

		private string _header;
		[Localizable(true)]
		public string Header
		{
			get { return _header; }
			set 
			{ 
				_header = value;
				OnHeaderChanged();
			}
		}

        private int _left;
        [Browsable(false)]
        public int Left
        {
            get { return _left; }
            set { _left = value; }
        }

		private int _width;
		[DefaultValue(50), Localizable(true)]
		public int Width
		{
			get
            {
                _width = Math.Max(_width, _minColumnWidth);
                if (_maxColumnWidth > 0)
                {
                    _width = Math.Min(_width, _maxColumnWidth);
                }
                return _width;
            }
			set 
			{
				if (_width != value)
				{
					if (value < 0)
						throw new ArgumentOutOfRangeException("value");

                    _width = Math.Max(MinColumnWidth, value);
                    if (_maxColumnWidth > 0)
                    {
                        _width = Math.Min(_width, _maxColumnWidth);
                    }
					OnWidthChanged();
				}
			}
		}

        private int _minColumnWidth;
        [DefaultValue(10)]
        public int MinColumnWidth
        {
            get { return _minColumnWidth; }
            set
            {
                _minColumnWidth = Math.Max(0, value);

                if (_minColumnWidth > MaxColumnWidth)
                {
                    MaxColumnWidth = _minColumnWidth + (_minColumnWidth - MaxColumnWidth);
                }

                Width = Math.Max(_minColumnWidth, _width);
            }
        }

        private int _maxColumnWidth;
        [DefaultValue(0)]
        public int MaxColumnWidth
        {
            get { return _maxColumnWidth; }
            set
            {
                _maxColumnWidth = Math.Max(0, value);
                if (_maxColumnWidth > 0)
                {
                    if (_maxColumnWidth < MinColumnWidth)
                    {
                        MinColumnWidth = _maxColumnWidth - (MinColumnWidth - _maxColumnWidth);
                    }
                    Width = Math.Min(_maxColumnWidth, _width);
                }
            }
        }

		private bool _visible = true;
		[DefaultValue(true)]
		public bool IsVisible
		{
			get { return _visible; }
			set 
			{ 
				_visible = value;
				OnIsVisibleChanged();
			}
		}

		private HorizontalAlignment _textAlign = HorizontalAlignment.Left;
		[DefaultValue(HorizontalAlignment.Left)]
		public HorizontalAlignment TextAlign
		{
			get { return _textAlign; }
			set 
			{
				if (value != _textAlign)
				{
					_textAlign = value;
                    _headerFlags = _baseHeaderFlags | TextHelper.TranslateAligmentToFlag(value);
					OnHeaderChanged();
				}
			}
		}

        private bool _sortable = false;
        [DefaultValue(false)]
        public bool Sortable
        {
            get { return _sortable; }
            set { _sortable = value; }
        }

		private SortOrder _sort_order = SortOrder.None;
		public SortOrder SortOrder
		{
			get { return _sort_order; }
			set
			{
				if (value == _sort_order)
					return;
				_sort_order = value;
				OnSortOrderChanged();
			}
		}

		public Size SortMarkSize
		{
			get
			{
				if (Application.RenderWithVisualStyles)
					return new Size(9, 5);
				else
					return new Size(7, 4);
			}
		}
		#endregion

		public TreeColumn(): 
			this(string.Empty, 50, 10, 0)
		{
		}

        public TreeColumn(string header, int width, int minColumnWidth, int maxColumnWidth)
		{
			_header = header;
			_width = width;
            _minColumnWidth = minColumnWidth;
            _maxColumnWidth = maxColumnWidth;

            _headerFlags = new TextFormatFlags();
            _headerFlags = _baseHeaderFlags | TextFormatFlags.Left;

		}

		public override string ToString()
		{
			if (string.IsNullOrEmpty(Header))
				return GetType().Name;
			else
				return Header;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		#region Draw

		private static VisualStyleRenderer _normalRenderer;
		private static VisualStyleRenderer _pressedRenderer;
		private static VisualStyleRenderer _hotRenderer;

		private static void CreateRenderers()
		{
			if (Application.RenderWithVisualStyles && _normalRenderer == null)
			{
				_normalRenderer = new VisualStyleRenderer(VisualStyleElement.Header.Item.Normal);
				_pressedRenderer = new VisualStyleRenderer(VisualStyleElement.Header.Item.Pressed);
				_hotRenderer = new VisualStyleRenderer(VisualStyleElement.Header.Item.Hot);
			}
		}

		internal Bitmap CreateGhostImage(Rectangle bounds, Font font)
		{
			Bitmap b = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
			Graphics gr = Graphics.FromImage(b);
			gr.FillRectangle(SystemBrushes.ControlDark, bounds);
			DrawContent(gr, bounds, font);
			BitmapHelper.SetAlphaChanelValue(b, 150);
			return b;
		}

		internal void Draw(Graphics gr, Rectangle bounds, Font font, bool pressed, bool hot)
		{
			DrawBackground(gr, bounds, pressed, hot);
			DrawContent(gr, bounds, font);
		}

        private void DrawContent(Graphics gr, Rectangle bounds, Font font)
        {
            Size textSize = new Size();
            Size maxTextSize = new Size();

            Size oldBoundSize = new Size(bounds.Width + 7 - (HeaderLeftMargin + HeaderRightMargin), bounds.Height);

            bounds = new Rectangle(bounds.X + HeaderLeftMargin, bounds.Y,
                                   bounds.Width - HeaderLeftMargin - HeaderRightMargin,
                                   bounds.Height);

            if (SortOrder != SortOrder.None)
            {
                if (TextAlign == HorizontalAlignment.Right)
                {
                    bounds.Width -= (SortMarkSize.Width + SortOrderMarkMargin + 5);
                    oldBoundSize.Width -= (SortMarkSize.Width + SortOrderMarkMargin + 5);
                }
                else
                {
                    bounds.Width -= (SortMarkSize.Width + SortOrderMarkMargin);
                    oldBoundSize.Width -= (SortMarkSize.Width + SortOrderMarkMargin);
                }
            }

            maxTextSize = TextRenderer.MeasureText(Header, font);
            textSize = TextRenderer.MeasureText(Header, font, oldBoundSize, _baseHeaderFlags);

            if (SortOrder != SortOrder.None)
            {
                int tw = Math.Min(textSize.Width, bounds.Size.Width);

                int x = 0;
                if (TextAlign == HorizontalAlignment.Left)
                    x = bounds.X + tw + SortOrderMarkMargin;
                else if (TextAlign == HorizontalAlignment.Right)
                    x = 5 + bounds.Right + SortOrderMarkMargin;
                else
                    x = bounds.X + tw + (bounds.Width - tw) / 2 + SortOrderMarkMargin;
                DrawSortMark(gr, new Rectangle(x, bounds.Y, 0, bounds.Height), bounds.Width, bounds.X);
            }

            if (textSize.Width < maxTextSize.Width)
            {
                TextRenderer.DrawText(gr, Header, font, bounds, SystemColors.ControlText, _baseHeaderFlags | TextFormatFlags.Left);
            }
            else
            {
                TextRenderer.DrawText(gr, Header, font, bounds, SystemColors.ControlText, _headerFlags);
            }
        }

		private void DrawSortMark(Graphics gr, Rectangle bounds, int width, int left)
		{
			int x = bounds.X;
			int y = bounds.Y + bounds.Height / 2 - 2;

            if (x < left + 5)
            {
                x = left + 5;
            }

            Region r = gr.Clip;
            int w = Math.Max(Math.Min(SortMarkSize.Width, width + SortMarkSize.Width + SortOrderMarkMargin), 0);
            gr.Clip = new Region(new RectangleF(x, y, w, SortMarkSize.Height));

            int w2 = SortMarkSize.Width / 2;
            if (SortOrder == SortOrder.Ascending)
            {
                Point[] points = new Point[] { new Point(x, y), new Point(x + SortMarkSize.Width, y), new Point(x + w2, y + SortMarkSize.Height) };
                gr.FillPolygon(SystemBrushes.ControlDark, points);
            }
            else if (SortOrder == SortOrder.Descending)
            {
                Point[] points = new Point[] { new Point(x - 1, y + SortMarkSize.Height), new Point(x + SortMarkSize.Width, y + SortMarkSize.Height), new Point(x + w2, y - 1) };
                gr.FillPolygon(SystemBrushes.ControlDark, points);
            }

            gr.Clip = r;
		}

		internal static void DrawDropMark(Graphics gr, Rectangle rect)
		{
			gr.FillRectangle(SystemBrushes.HotTrack, rect.X-1, rect.Y, 2, rect.Height);
		}

		internal static void DrawBackground(Graphics gr, Rectangle bounds, bool pressed, bool hot)
		{
			if (Application.RenderWithVisualStyles)
			{
				CreateRenderers();
				if (pressed)
					_pressedRenderer.DrawBackground(gr, bounds);
				else if (hot)
					_hotRenderer.DrawBackground(gr, bounds);
				else
					_normalRenderer.DrawBackground(gr, bounds);
			}
			else
			{
				gr.FillRectangle(SystemBrushes.Control, bounds);
				Pen p1 = SystemPens.ControlLightLight;
				Pen p2 = SystemPens.ControlDark;
				Pen p3 = SystemPens.ControlDarkDark;
				if (pressed)
					gr.DrawRectangle(p2, bounds.X, bounds.Y, bounds.Width, bounds.Height);
				else
				{
					gr.DrawLine(p1, bounds.X, bounds.Y, bounds.Right, bounds.Y);
					gr.DrawLine(p3, bounds.X, bounds.Bottom, bounds.Right, bounds.Bottom);
					gr.DrawLine(p3, bounds.Right - 1, bounds.Y, bounds.Right - 1, bounds.Bottom - 1);
					gr.DrawLine(p1, bounds.Left, bounds.Y + 1, bounds.Left, bounds.Bottom - 2);
					gr.DrawLine(p2, bounds.Right - 2, bounds.Y + 1, bounds.Right - 2, bounds.Bottom - 2);
					gr.DrawLine(p2, bounds.X, bounds.Bottom - 1, bounds.Right - 2, bounds.Bottom - 1);
				}
			}
		}

		#endregion

		#region Events

		public event EventHandler HeaderChanged;
		private void OnHeaderChanged()
		{
			if (HeaderChanged != null)
				HeaderChanged(this, EventArgs.Empty);
		}

		public event EventHandler SortOrderChanged;
		private void OnSortOrderChanged()
		{
			if (SortOrderChanged != null)
				SortOrderChanged(this, EventArgs.Empty);
		}

		public event EventHandler IsVisibleChanged;
		private void OnIsVisibleChanged()
		{
			if (IsVisibleChanged != null)
				IsVisibleChanged(this, EventArgs.Empty);
		}

		public event EventHandler WidthChanged;
		private void OnWidthChanged()
		{
			if (WidthChanged != null)
				WidthChanged(this, EventArgs.Empty);
		}

		#endregion
	}
}
