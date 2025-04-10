using CompositeTask;

Random rnd = new();

LightElementNode table = new LightElementNode("table", ["col-6"], []);

LightElementNode thead = new("thead", [], []);
table.Children.Add(thead);
LightElementNode headRow = new("tr", [], []);
thead.Children.Add(headRow);
LightElementNode headTitle1 = new("td", [], []);
headRow.Children.Add(headTitle1);
LightTextNode headTitle1Text = new("Title");
headTitle1.Children.Add(headTitle1Text);
LightElementNode headTitle2 = new("td", [], []);
headRow.Children.Add(headTitle2);
LightTextNode headTitle2Text = new("Litres");
headTitle2.Children.Add(headTitle2Text);
LightElementNode headTitle3 = new("td", [], []);
headRow.Children.Add(headTitle3);
LightTextNode headTitle3Text = new("Fuel Type");
headTitle3.Children.Add(headTitle3Text);


LightElementNode tbody = new("tbody", [], []);
table.Children.Add(tbody);

for (int i = 0; i < 5; i++)
{
    LightElementNode row = new("tr", [], []);
    tbody.Children.Add(row);

    LightElementNode titleCell = new("td", ["p3"], []);
    row.Children.Add(titleCell);
    LightTextNode titleTexNode = new($"Title {i+1}");
    titleCell.Children.Add(titleTexNode);

    LightElementNode capacityCell = new("td", ["p3"], []);
    row.Children.Add(capacityCell);
    LightTextNode capacityTexNode = new($"{ rnd.Next(10, 20)}");
    capacityCell.Children.Add(capacityTexNode);

    LightElementNode fuelTypeCell = new("td", ["p3"], []);
    row.Children.Add(fuelTypeCell);
    string fuelType = rnd.Next(0, 2) == 1 ? "Diesel" : "Gasoline";
    LightTextNode fuelTypeTexNode = new($"{fuelType}");
    fuelTypeCell.Children.Add(fuelTypeTexNode);

}

Console.WriteLine($"{table.OuterHTML}");


