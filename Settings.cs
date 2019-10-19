using ExileCore.Shared.Attributes;
using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;
using SharpDX;

namespace DelveWalls
{
    //All properties and public fields of this class will be saved to file
    public class Settings : ISettings
    {
        [Menu("Enable")]
        public ToggleNode Enable { get; set; }
        [Menu("Azurite Color")]
        public ColorNode AzuriteColor { get; set; } = new ColorNode(Color.Blue);
        [Menu("Currency Color")]
        public ColorNode CurrencyColor { get; set; } = new ColorNode(Color.Yellow);
        [Menu("Unique / Fossil Color")]
        public ColorNode UniqueFossilColor { get; set; } = new ColorNode(Color.Orange);
        [Menu("Resonator Color")]
        public ColorNode ResColor { get; set; } = new ColorNode(Color.Gray);
        [Menu("Delve Wall Color")]
        public ColorNode WallColor { get; set; } = new ColorNode(Color.Purple);
        [Menu("Position X")]
        public RangeNode<int> PosX { get; set; } = new RangeNode<int>(960, 480, 1280);
        [Menu("Position Y")]
        public RangeNode<int> PosY { get; set; } = new RangeNode<int>(540, 270, 720);
        [Menu("Arrow Size")]
        public RangeNode<int> ArrowSize { get; set; } = new RangeNode<int>(40, 20, 80);


        public Settings()
        {
            Enable = new ToggleNode(true);
        }

    }
}