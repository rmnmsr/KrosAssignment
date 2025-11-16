tp.Test("Project should have ID", () => {
    dynamic project = tp.Response.GetBodyAsExpando();
    True(project.id > 0);
});

tp.Test("Project name should match", () => {
    dynamic project = tp.Response.GetBodyAsExpando();
    Equal("Test Project", project.name);
});

dynamic responseBody = tp.Response.GetBodyAsExpando();
tp.SetVariable("ProjectId", responseBody.id);
