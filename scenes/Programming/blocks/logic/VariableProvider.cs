using Godot;

namespace GetOn.scenes.Programming.blocks.logic {
    public static class VariableProvider {
        
        public static Node2D PlayerNode;
        public static Node2D FlagNode;

        public static int RandomInt() {
            return new RandomNumberGenerator().RandiRange(0, int.MaxValue);
        }

    }
}