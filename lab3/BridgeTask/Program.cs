using BridgeTask;

IRasterizer pxRast = new PixelRasterizer();
IRasterizer vcRast = new VectorRasterizer();

List<Shape> shapes = [
    new Square(0, 0, pxRast, 4, "red"),
    new Square(1, 2, vcRast, 4, "dark red"),
    new Circle(2, 2, pxRast, 2, "dark green"),
    new Circle(1, 4, vcRast, 2, "green"),
];

foreach (Shape shape in shapes)
    shape.Draw();
