tp.Test("Should return array of employees", () => {
    var body = tp.Response.GetBody();
    True(body.StartsWith("["));
});

tp.Test("Should have at least one employee", () => {
    var body = tp.Response.GetBody();
    True(body.Length > 2); // More than just []
});
