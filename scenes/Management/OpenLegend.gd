extends Control

var image : Sprite
var is_image_visible : bool = false

func _ready() -> void:
	# Assuming your TextureRect node is named "ImageNode" (you should replace this with the actual name)
	image = $Legend
	image.visible = false # Initially hide the image


func _on_Legend2_pressed() -> void:
	if is_image_visible:
		# If the image is currently visible, hide it
		image.visible = false
		is_image_visible = false
	else:
		# If the image is not visible, show it
		image.visible = true
		is_image_visible = true

