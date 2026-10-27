namespace Content.Shared._Citadel.Worldgen.GridStructures;

public sealed class GridStructureAnalyzer
{
    /// <summary>
    /// Analyzes a grid structure pack and returns the analysis result.
    /// </summary>
    /// <param name="pack"></param>
    /// <returns></returns>
    private GridStructurePackAnalysis Analyze(GridStructurePackPrototype pack)
    {
#warning impl
        return new GridStructurePackAnalysis
        {
#warning impl
        };
    }

    public record Success
    {
        public GridStructurePackAnalysis Analysis { get; init; } = default!;
    }

    public record Error
    {
        public string Message { get; init; } = default!;
    }
}
