extends Node

func _print(name, points, time):
	print_debug("Printing PDF via JS. Content: " + name);
	var window = JavaScript.get_interface("window");
	var pointsString = "Points: %d" % points;
	var timeString = "Time remaining: " + time;
	window.print(name, pointsString, timeString);
	
