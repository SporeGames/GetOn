using System;
using System.Threading;
using Godot;
using Thread = System.Threading.Thread;

namespace GetOn.scenes.Programming.blocks.logic {
    public class BlockExecutor {

        private ThreadStart _threadStart;
        public Thread ExecutionThread { get; private set; }

        public AbstractBlock StartBlock;

        public void Start() {
            if (StartBlock == null) {
                GD.PrintErr("No start block set!");
                return;
            }
            _threadStart = Execute;
            ExecutionThread = new Thread(_threadStart);
            ExecutionThread.Start();
        }

        // Run the block execution in a separate thread to not stall the game.
        private void Execute() {
            try {
                StartBlock.Run();
            }
            catch (Exception e) {
                if (e is ThreadAbortException) {
                    GD.Print("Thread aborted.");
                    return;
                }
                if (e is BlockLogicException) {
                    Console.WriteLine(e.Message);
                    return;
                }
                GD.Print("Unknown exception occurred during block execution: " + e.Message);
                GD.Print(e.StackTrace);
            }
        }

        public void Kill() {
            ExecutionThread.Abort();
        }
    }
}