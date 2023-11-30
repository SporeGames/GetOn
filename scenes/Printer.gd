extends Node

func _print(name, points, time, gameStudyPoints, gameDesignPoints, soundPoints, managementPoints, managementColors, narrativePoints):
	print_debug("Printing PDF via JS. Content: " + name);
	var window = JavaScript.get_interface("window");
	var pointsString = "Points: %d" % points;
	var timeString = "Time remaining: " + time;
	var gameStudyPointsString = "Game Study Points: %d" % gameStudyPoints;
	var gameDesignPointsString = "Game Design Points: %d" % gameDesignPoints;
	var narrativePointsString = "Narrative Points: %d" % narrativePoints;
	var managementPointsString = "Management Points: %d" % managementPoints;
	var managementColorString = "Cards colored correctly: %d" % managementColors;
	var soundPointsString = "Sound Points: %d" % soundPoints;
	window.print(name, pointsString, timeString, gameStudyPointsString, narrativePointsString, managementPointsString, managementColorString, soundPointsString, gameDesignPointsString);
	
