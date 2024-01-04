using GetOn.scenes.Programming.blocks.logic;
using Godot;

namespace GetOn.scenes.Programming.blocks {
    public class MoveTruckBlock : AbstractBlock {
        public MoveTruckBlock() {
            Name = "MoveTruckBlock";
        }
		
        public override BlockVariable Execute() {
            GetNode<KinematicBody2D>("/root/Programming/Game/Truck").MoveAndSlide(new Vector2(200, 0));
            return new BlockVariable("truckReturn", this, true);
        }
		
        public override bool Validate() {
            return true;
        }
    }
}