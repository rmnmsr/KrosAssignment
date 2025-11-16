tp.Test("Should return array of divisions", () => {
    var body = tp.Response.GetBody();
    True(body.StartsWith("["));
});
