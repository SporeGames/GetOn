using System;
using GetOn.scenes.Programming.blocks.godot;
using Godot;

namespace GetOn.scenes.Programming.blocks.logic {
    public class BlockVariable {
        public BlockVariableType Type { get; }
        public GodotNode Block { get; }
        public String id;
        public int IntValue { set; private get; }
        public float FloatValue { set; private get; }
        public bool BoolValue;
        public string StringValue;
        public Vector2 VectorValue;
        public Node2D NodeValue;

        public bool isProvidedByBlock = false;

        public BlockVariable() {
            
        }

        public BlockVariable(string id, BlockVariableType type, GodotNode block) {
            Type = type;
            Block = block;
            this.id = id;
        }
        
        public BlockVariable(string id, GodotNode block, int value) {
            Block = block;
            Type = BlockVariableType.Int;
            IntValue = value;
            this.id = id;
        }
        
        public BlockVariable(string id, GodotNode block, float value) {
            Block = block;
            Type = BlockVariableType.Float;
            FloatValue = value;
            this.id = id;
        }
        
        public BlockVariable(string id, GodotNode block, bool value) {
            Block = block;
            Type = BlockVariableType.Bool;
            BoolValue = value;
            this.id = id;
        }
        
        public BlockVariable(string id, GodotNode block, string value) {
            Block = block;
            Type = BlockVariableType.String;
            StringValue = value;
            this.id = id;
        }
        
        public BlockVariable(string id, GodotNode block, Vector2 value) {
            Block = block;
            Type = BlockVariableType.Vector;
            VectorValue = value;
            this.id = id;
        }
        
        public BlockVariable(string id, GodotNode block, Node2D value) {
            Block = block;
            Type = BlockVariableType.Node;
            NodeValue = value;
            this.id = id;
        }

        public BlockVariable(GodotNode block, string placeholder) {
            this.id = placeholder;
            Block = block;
        }

        public int getInt() {
            if (isProvidedByBlock && Block is AbstractBlock abstractBlock) {
                return abstractBlock.getInt();
            }
            return IntValue;
        }
        
        public float getFloat() {
            if (isProvidedByBlock && Block is AbstractBlock abstractBlock) {
                return abstractBlock.getFloat();
            }
            return FloatValue;
        }
        
        public bool getBool() {
            if (isProvidedByBlock && Block is AbstractBlock abstractBlock) {
                return abstractBlock.getBool();
            }
            return BoolValue;
        }
        
        public BlockVariable SetProvidedByBlock(bool value) {
            isProvidedByBlock = value;
            return this;
        }
    }
}