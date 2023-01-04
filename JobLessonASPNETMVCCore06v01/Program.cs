using Autofac;
using Autofac.Features.Metadata;



var builder = new ContainerBuilder();
builder.RegisterType<PDFPipelineItem>().As<IPipelineItem>().WithMetadata("Name", "PDF");
builder.RegisterType<ImagePipelineItem>().As<IPipelineItem>().WithMetadata("Name", "Image");
builder.RegisterAdapter<Meta<IPipelineItem>, Operation>(cmd => new Operation(cmd.Value, (string)cmd.Metadata["Name"]));

IContainer container = builder.Build();
IReadOnlyList<Operation> operations = container.Resolve<IEnumerable<Operation>>().ToList();

foreach (Operation operation in operations)
{
    Console.WriteLine($"Выполняется процедура сканирования и сохранение в формате: {operation.Name}");
    operation.Execute();
    Console.WriteLine();
}



public interface IPipelineItem
{
    string Name { get; }
    void Run();
}
public abstract class PipelineItem : IPipelineItem
{
    public abstract string Name { get; }
    public abstract void Run();
}
public sealed class PDFPipelineItem : PipelineItem

{
    public override string Name => $"{nameof(PDFPipelineItem)}";
    public override void Run()
    {
        Console.WriteLine($"Текущий класс: {Name}");
    }
}
public sealed class ImagePipelineItem : PipelineItem
{
    public override string Name => $"{nameof(ImagePipelineItem)}";
    public override void Run()
    {
        Console.WriteLine($"Текущий класс: {Name}");
    }
}
public sealed class Operation
{
    private readonly IPipelineItem _pipelineItem;
    private readonly string _name;
    public Operation(IPipelineItem pipelineItem, string name)
    {
        _pipelineItem = pipelineItem;
        _name = name;
    }
    public string Name => _name;
    public void Execute()
    {
        _pipelineItem.Run();
    }
}