using FlyweightTask;

Random rnd = new();

NodeInfoFactory factory = new();

LightElementNodeInfo
        defaultParagraphInfo = factory.GetParticle(new LightElementNodeInfo("p")),
        defaultHeader1Info = factory.GetParticle(new LightElementNodeInfo("h1")),
        defaultHeader2Info = factory.GetParticle(new LightElementNodeInfo("h2")),
        defaultBlockquoteInfo = factory.GetParticle(new LightElementNodeInfo("blockquote"));


LightElementNode body = new("div");

LightElementNode header1 = new(defaultHeader1Info, parent: body);
LightTextNode header1Text = new("ACT V", header1);

LightElementNode paragraph1 = new(defaultParagraphInfo, parent: body);
LightTextNode paragraph1Text = new("Scene I. Mantua. A Street.", paragraph1);

LightElementNode paragraph2 = new(defaultParagraphInfo, parent: body);
LightTextNode paragraph2Text = new("Scene II. Friar Lawrence’s Cell.", paragraph2);

LightElementNode paragraph3 = new(defaultParagraphInfo, parent: body);
LightTextNode paragraph3Text = new("Scene III. A churchyard; in it a Monument belonging to the Capulets.", paragraph3);

LightElementNode qoute = new(defaultBlockquoteInfo, parent: body);
LightTextNode qouteText = new("Dramatis Personae", qoute);

LightElementNode paragraph4 = new(defaultParagraphInfo, parent: body);
LightTextNode paragraph4Text = new("ESCALUS, Prince of Verona.", paragraph4);

LightElementNode paragraph5 = new(defaultParagraphInfo, parent: body);
LightTextNode paragraph5Text = new("MERCUTIO, kinsman to the Prince, and friend to Romeo.", paragraph5);

LightElementNode paragraph6 = new(defaultParagraphInfo, parent: body);
LightTextNode paragraph6Text = new("PARIS, a young Nobleman, kinsman to the Prince.", paragraph6);

LightElementNode header2 = new(defaultHeader2Info, parent: body);
LightTextNode header2Text = new("Page to Paris.", header2);

Console.WriteLine(body.OuterHTML);

/*
ACT V
Scene I. Mantua. A Street.
Scene II. Friar Lawrence’s Cell.
Scene III. A churchyard; in it a Monument belonging to the Capulets.

 Dramatis Personae
-------------------- (20 Characters)
ESCALUS, Prince of Verona.
MERCUTIO, kinsman to the Prince, and friend to Romeo.
PARIS, a young Nobleman, kinsman to the Prince.
Page to Paris.
*/