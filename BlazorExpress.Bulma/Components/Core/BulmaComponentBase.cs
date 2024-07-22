namespace BlazorExpress.Bulma;

public abstract class BulmaComponentBase : ComponentBase, IDisposable, IAsyncDisposable
{
    #region Fields and Constants

    private bool isAsyncDisposed;

    private bool isDisposed;

    #endregion

    #region Methods

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        IsRenderComplete = true;

        await base.OnAfterRenderAsync(firstRender);
    }

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        Id ??= IdUtility.GetNextId();

        base.OnInitialized();
    }

    /// <inheritdoc />
    /// <seealso cref="https://learn.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-6.0" />
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc />
    /// <seealso
    ///     cref="https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-disposeasync#implement-both-dispose-and-async-dispose-patterns" />
    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore(true).ConfigureAwait(false);

        Dispose(false);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!isDisposed)
        {
            if (disposing)
            {
                // cleanup
            }

            isDisposed = true;
        }
    }

    protected virtual ValueTask DisposeAsyncCore(bool disposing)
    {
        if (!isAsyncDisposed)
        {
            if (disposing)
            {
                // cleanup
            }

            isAsyncDisposed = true;
        }

        return ValueTask.CompletedTask;
    }

    #endregion

    #region Properties, Indexers

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> AdditionalAttributes { get; set; } = default!;

    [Parameter] 
    public string? Class { get; set; }

    protected virtual string? CssClassNames => Class;

    public ElementReference Element { get; set; }

    [Parameter] 
    public string? Id { get; set; }

    protected bool IsRenderComplete { get; private set; }

    [Inject] 
    protected IJSRuntime JSRuntime { get; set; } = default!;

    [Parameter] 
    public string? Style { get; set; }

    protected virtual string? CssStyleNames => @Style;

    #endregion

    #region Other

    ~BulmaComponentBase()
    {
        Dispose(false);
    }

    #endregion
}
