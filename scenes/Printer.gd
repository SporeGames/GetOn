extends Node

func _print(jsonString):
	print_debug("Printing PDF via JS. Content: " + jsonString);
	var window = JavaScript.get_interface("window");
	window.print(jsonString);
	
