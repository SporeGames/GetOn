using Godot;
using System;

public class SnapArea : Area2D
{
	private bool area1;
	private bool area2;
	private bool leftClick;
	private string nameCopy;
	private string nameCopy2;
	private DragAndDropStory _ending1;
	private DragAndDropStory _ending2;
	private DragAndDropStory _ending3;
	private DragAndDropStory _ending21;
	private DragAndDropStory _ending22;
	private DragAndDropStory _ending23;
	private DragAndDropStory copy;
	private Node2D _firstStory;
	private bool firstStoryVisible;
	public override void _Ready() {
		_ending1 = GetNode<DragAndDropStory>("/root/Narrative/1/Ending1");
		_ending2 = GetNode<DragAndDropStory>("/root/Narrative/1/Ending2");
		_ending3 = GetNode<DragAndDropStory>("/root/Narrative/1/Ending3");
		
		_ending21 = GetNode<DragAndDropStory>("/root/Narrative/2/Ending21");
		_ending22 = GetNode<DragAndDropStory>("/root/Narrative/2/Ending22");
		_ending23 = GetNode<DragAndDropStory>("/root/Narrative/2/Ending23");

		_firstStory = GetNode<Node2D>("/root/Narrative/1");
	}

	public override void _Process(float delta) {
		if(_firstStory.Visible == true) {
			firstStoryVisible = true;
		}
		else {
			firstStoryVisible = false;
		}
	}

	public override void _Input(InputEvent @event) {
		if (Input.IsActionPressed("left_click")) {
			leftClick = true;
		}

		if (Input.IsActionJustReleased("left_click")) {
			leftClick = false;
			if (area1) {
				Snap(nameCopy, new Vector2(969, 750), false);
			}
			if (area2) {
				Snap(nameCopy2, new Vector2(969, 750), false);
			}
		}
	}

	public void Snap(string name, Vector2 position, bool empty) {
		if (!empty) {
			if (name == "Ending1") {
				copy = _ending1;
			}
			if (name == "Ending2") {
				copy = _ending2;
			}
			if (name == "Ending3") {
				copy = _ending3;
			}
			if (name == "Ending21") {
				copy = _ending21;
			}
			if (name == "Ending22") {
				copy = _ending22;
			}
			if (name == "Ending23") {
				copy = _ending23;
			}
		}
		if (copy != null) {
			copy.ChangePosition(position);
		}
	}

	private void _on_SnapArea_body_entered(object body) {
		if (body is KinematicBody2D kinematicBody) {
			if (area1 == false && firstStoryVisible == true) {
				nameCopy = kinematicBody.Name;
				area1 = true;
			}
			if (area2 == false && firstStoryVisible == false) {
				nameCopy2 = kinematicBody.Name;
				area2 = true;
			}
		}
	}
	
	private void _on_SnapArea_body_exited(object body) {
		if (body is KinematicBody2D kinematicBody) {
			if (kinematicBody.Name == nameCopy && firstStoryVisible == true) {
				area1 = false;
			}
			if (kinematicBody.Name == nameCopy2 && firstStoryVisible == false) {
				area2 = false;
			}
		}
	}
}



