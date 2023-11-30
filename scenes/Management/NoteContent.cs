using Godot;

namespace GetOn.scenes.Management {
    public class NoteContent : Resource {
        [Export] public string Content { get; set; } = "test";
        [Export] public Color Color { get; set; } = Colors.White;
        
        public NoteContent() : this(null, Colors.White) {}

        public NoteContent(string content, Color color) {
            Content = content;
            Color = color;
        }
    }
}