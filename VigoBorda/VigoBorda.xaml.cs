using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VigoBorda
{
    public partial class VigoBorda : UserControl
    {
        public VigoBorda()
        {
            InitializeComponent();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            Matrix m = PresentationSource.FromVisual(this).CompositionTarget.TransformToDevice;
            double dpiFactor = 1 / m.M11;

            Pen pen = new Pen(Brushes.Black, 1 * dpiFactor);
            //Pen pen2 = new Pen(Brushes.White, 1 * dpiFactor);

            Rect rect = new Rect(0, 0, this.Width - 1, this.Height - 1);

            //Point p1 = new Point(0, 0);
            //Point p2 = new Point(0, 49);
            //Point p3 = new Point(this.Width - 1, 0);
            //Point p4 = new Point(this.Width - 1, 49);
            //Point p5 = new Point(0, 0);
            //Point p6 = new Point(this.Width - 1, 0);
            //Point p7 = new Point(0, 49);
            //Point p8 = new Point(this.Width - 1, 49);

            double halfPenWidth = pen.Thickness / 2;

            GuidelineSet guidelines = new GuidelineSet();

            guidelines.GuidelinesX.Add(rect.Left + halfPenWidth);
            guidelines.GuidelinesX.Add(rect.Right + halfPenWidth);
            guidelines.GuidelinesY.Add(rect.Top + halfPenWidth);
            guidelines.GuidelinesY.Add(rect.Bottom + halfPenWidth);

            drawingContext.PushGuidelineSet(guidelines);
            drawingContext.DrawRectangle(null, pen, rect);

            //if (Borda.Left == 0)
            //    drawingContext.DrawLine(pen2, p1, p2);

            //if (Borda.Right == 0)
            //    drawingContext.DrawLine(pen2, p3, p4);

            //if (Borda.Top == 0)
            //    drawingContext.DrawLine(pen2, p5, p6);

            //if (Borda.Bottom == 0)
            //    drawingContext.DrawLine(pen2, p7, p8);

            drawingContext.Pop();
        }

        //public static readonly DependencyProperty BordaProperty = DependencyProperty.Register("Borda", typeof(Thickness), typeof(VigoBorda), new FrameworkPropertyMetadata(new Thickness(1)));
        //public Thickness Borda
        //{
        //    get { return (Thickness)GetValue(BordaProperty); }
        //    set
        //    {
        //        SetValue(BordaProperty, value);
        //    }
        //}
    }
}
