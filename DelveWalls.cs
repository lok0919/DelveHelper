using ExileCore;
using ExileCore.PoEMemory.MemoryObjects;
using ExileCore.Shared.Helpers;
using SharpDX;

namespace DelveWalls
{
    public class DelveWalls : BaseSettingsPlugin<Settings>
    {
        private IngameUIElements _inGameUi;

        public override void OnLoad()
        {
        }

        public override bool Initialise()
        {
            _inGameUi = GameController.IngameState.IngameUi;
            return true;
        }

        public override void Render()
        {
            if (!GameController.InGame)
                return;
            if (GameController.Area.CurrentArea.IsTown)
                return;
            if (GameController.Area.CurrentArea.IsHideout)
                return;
            if (GameController.IsLoading)
                return;
            if (_inGameUi.StashElement.IsVisible)
                return;
            if (_inGameUi.InventoryPanel.IsVisible)
                return;
            if (_inGameUi.OpenLeftPanel.IsVisible)
                return;
            if (_inGameUi.OpenRightPanel.IsVisible)
                return;

            var entities = GameController.Entities;
            if (entities == null)
                return;
            foreach (var e in entities)
            {
                if (e.Path.Contains("DelveWall") && DrawArrow(e))
                {
                    return;
                }
            }
        }

        public bool DrawArrow (Entity e)
        {
            if (!e.IsAlive)
                return false;
            var delta = e.GridPos - GameController.Player.GridPos;
            var distance = delta.GetPolarCoordinates(out var phi);
            if (distance > 250) return false;
            var dir = MathHepler.GetDirectionsUV(phi, distance);
            //LogMessage($"Wall close Distance {distance}  Direction {Dir}", 1);
            var center = new Vector2(960, 540);
            var rectDirection = new RectangleF(center.X-20, center.Y-40, 40, 40);
            Graphics.DrawImage("directions.png", rectDirection, dir, Color.LightGreen);
            return true;
        }
    }
}