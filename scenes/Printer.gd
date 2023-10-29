extends Node

func _print(text):
	print_debug("Printing PDF via JS. Content: " + text)
	var window = JavaScript.get_interface("window");
	window.print(text);
	
