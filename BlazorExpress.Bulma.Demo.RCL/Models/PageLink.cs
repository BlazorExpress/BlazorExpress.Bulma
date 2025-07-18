﻿namespace BlazorExpress.Bulma.Demo.RCL.Models;

public class PageLink
{
    public int Id { get; set; }
    public BootstrapIconName IconName { get; set; } = default!;
    public string Href { get; set; } = default!;
    public string Text { get; set; } = default!;
    public int SortOrder { get; set; }
    public HashSet<PageLinkCategory> Categories { get; set; } = new();
    public PageLinkStatus Status { get; set; }
    public bool IsActive { get; set; }
}
