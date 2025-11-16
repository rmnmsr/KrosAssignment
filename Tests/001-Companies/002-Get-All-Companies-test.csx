tp.Test("Should return array of companies", () => {
    var body = tp.Response.GetBody();
    True(body.StartsWith("["));
});

tp.Test("Should have at least one company", () => {
    var body = tp.Response.GetBody();
    True(body.Length > 2); // More than just []
});
