using System.Collections.Generic;
using GetOn.scenes.Programming.blocks.godot;
using Godot;

namespace GetOn.scenes.Programming.blocks.logic {
    public class AbstractBlock : BlockNode {
        
        public string Name { get; set; }
        public AbstractBlock NextBlock { get; set; }
        public BlockVariableType ReturnType { get; set; }
        public List<BlockVariable> Inputs { get; set; }
        public List<BlockVariableType> InputTypes { get; set; }

        protected string ValidationErrorMessage = "Block validation failed!";
        

        public void Run() {
            if (!Validate()) {
                throw new BlockLogicException(ValidationErrorMessage);
            }
            var returnValue = Execute();
            if (NextBlock != null) {
                NextBlock.Run();
            }
        }
        
        public virtual BlockVariable Execute() {
            throw new BlockLogicException("Abstract block cannot be executed!");
        }

        public virtual bool Validate() {
            throw new BlockLogicException("No validation implemented for this block!");
        }
        
        public void Connected() {
            foreach (var node in ConnectedVariables) {
                switch (node.Type) {
                    case BlockVariableType.Node:
                        Inputs.Add(new BlockVariable(this, node.GetPlayer()));
                        GD.Print("Added node input");
                        break;
                    case BlockVariableType.Int:
                        Inputs.Add(new BlockVariable(this, node.GetRandom()));
                        GD.Print("Added int input");
                        break;
                }
            }
        }
    }
}