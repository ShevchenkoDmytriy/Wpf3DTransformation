using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Wpf3DTransformation
{
    public partial class MainWindow : Window
    {
        private double rotationAngle = 5.0;

        public MainWindow()
        {
            InitializeComponent();
            Initialize3DModel();
            DisplayCoordinateAxes();
        }

        private void Initialize3DModel()
        {
            MeshGeometry3D meshGeometry = new MeshGeometry3D();

            // Визначте вершини прямокутної призми
            meshGeometry.Positions.Add(new Point3D(-1, -1, -1));
            meshGeometry.Positions.Add(new Point3D(1, -1, -1));
            meshGeometry.Positions.Add(new Point3D(1, 1, -1));
            meshGeometry.Positions.Add(new Point3D(-1, 1, -1));
            meshGeometry.Positions.Add(new Point3D(-1, -1, 1));
            meshGeometry.Positions.Add(new Point3D(1, -1, 1));
            meshGeometry.Positions.Add(new Point3D(1, 1, 1));
            meshGeometry.Positions.Add(new Point3D(-1, 1, 1));

            // Визначте грані прямокутної призми
            meshGeometry.TriangleIndices.Add(0);
            meshGeometry.TriangleIndices.Add(1);
            meshGeometry.TriangleIndices.Add(2);
            meshGeometry.TriangleIndices.Add(0);
            meshGeometry.TriangleIndices.Add(2);
            meshGeometry.TriangleIndices.Add(3);
            meshGeometry.TriangleIndices.Add(4);
            meshGeometry.TriangleIndices.Add(5);
            meshGeometry.TriangleIndices.Add(6);
            meshGeometry.TriangleIndices.Add(4);
            meshGeometry.TriangleIndices.Add(6);
            meshGeometry.TriangleIndices.Add(7);
            meshGeometry.TriangleIndices.Add(0);
            meshGeometry.TriangleIndices.Add(3);
            meshGeometry.TriangleIndices.Add(7);
            meshGeometry.TriangleIndices.Add(0);
            meshGeometry.TriangleIndices.Add(7);
            meshGeometry.TriangleIndices.Add(4);
            meshGeometry.TriangleIndices.Add(1);
            meshGeometry.TriangleIndices.Add(2);
            meshGeometry.TriangleIndices.Add(6);
            meshGeometry.TriangleIndices.Add(1);
            meshGeometry.TriangleIndices.Add(6);
            meshGeometry.TriangleIndices.Add(5);
            meshGeometry.TriangleIndices.Add(3);
            meshGeometry.TriangleIndices.Add(2);
            meshGeometry.TriangleIndices.Add(6);
            meshGeometry.TriangleIndices.Add(3);
            meshGeometry.TriangleIndices.Add(6);
            meshGeometry.TriangleIndices.Add(7);

            // Створіть GeometryModel3D для прямокутної призми
            GeometryModel3D prismModel = new GeometryModel3D();
            prismModel.Geometry = meshGeometry;
            prismModel.Material = new DiffuseMaterial(new SolidColorBrush(Colors.Yellow));

            // Додайте прямокутну призму до групи моделей
            mainModel3DGroup.Children.Add(prismModel);

            // Прив'яжіть групу моделей до Viewport3D
            viewport3D.Children.Add(new ModelVisual3D { Content = mainModel3DGroup });
        }

        private void DisplayCoordinateAxes()
        {
            // Display X axis
            DrawLine(new Point3D(-10, 0, 0), new Point3D(10, 0, 0), Colors.Red);

            // Display Y axis
            DrawLine(new Point3D(0, -10, 0), new Point3D(0, 10, 0), Colors.Green);

            // Display Z axis
            DrawLine(new Point3D(0, 0, -10), new Point3D(0, 0, 10), Colors.Blue);
        }

        private void DrawLine(Point3D start, Point3D end, Color color)
        {
            GeometryModel3D lineModel = new GeometryModel3D();
            MeshGeometry3D lineGeometry = new MeshGeometry3D();

            lineGeometry.Positions.Add(start);
            lineGeometry.Positions.Add(end);
            lineGeometry.TriangleIndices.Add(0);
            lineGeometry.TriangleIndices.Add(1);

            lineModel.Geometry = lineGeometry;
            lineModel.Material = new DiffuseMaterial(new SolidColorBrush(color));

            mainModel3DGroup.Children.Add(lineModel);
        }

        private void RotateModel(Vector3D axis, double angle)
        {
            AxisAngleRotation3D rotation = new AxisAngleRotation3D(axis, angle);
            RotateTransform3D rotateTransform = new RotateTransform3D(rotation);
            mainModel3DGroup.Transform = rotateTransform;
        }

        private void ScaleModel(Vector3D scale)
        {
            ScaleTransform3D scaleTransform = new ScaleTransform3D(scale);
            mainModel3DGroup.Transform = scaleTransform;
        }

        private void RotateX_Click(object sender, RoutedEventArgs e)
        {
            RotateModel(new Vector3D(1, 0, 0), rotationAngle);
        }

        private void RotateY_Click(object sender, RoutedEventArgs e)
        {
            RotateModel(new Vector3D(0, 1, 0), rotationAngle);
        }

        private void RotateZ_Click(object sender, RoutedEventArgs e)
        {
            RotateModel(new Vector3D(0, 0, 1), rotationAngle);
        }

        private void RotateAll_Click(object sender, RoutedEventArgs e)
        {
            RotateModel(new Vector3D(1, 1, 1), rotationAngle);
        }

        private void ScaleX_Click(object sender, RoutedEventArgs e)
        {
            ScaleModel(new Vector3D(2, 1, 1));
        }

        private void ScaleY_Click(object sender, RoutedEventArgs e)
        {
            ScaleModel(new Vector3D(1, 2, 1));
        }

        private void ScaleZ_Click(object sender, RoutedEventArgs e)
        {
            ScaleModel(new Vector3D(1, 1, 2));
        }

        private void ScaleAll_Click(object sender, RoutedEventArgs e)
        {
            ScaleModel(new Vector3D(2, 2, 2));
        }
    }
}
