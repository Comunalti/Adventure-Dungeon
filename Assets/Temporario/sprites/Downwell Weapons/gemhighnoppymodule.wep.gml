#define init
global.sprite = sprite_add_weapon("GemHighNoppyModule.png", 2, 3);
global.shot = sprite_add("Bullet 2 (Gem High).png",2,11,6)
global.hit = sprite_add("Bullet Hit (Gem High).png",3,2,2)
global.sound = sound_add("Noppy Module Shot (Gem High).ogg")
global.swap = sound_add("Module Swap.ogg")

#define weapon_name
	return "Gem High Noppy Module";

#define weapon_type
	return 1;

#define weapon_area
	return 9;

#define weapon_cost
	return 1;

#define weapon_auto
	return true;

#define weapon_load 
	return 2.1;

#define weapon_swap
	return global.swap;
	
#define weapon_sprt
	return global.sprite;

#define weapon_text
	return "@rGematized @wspeed";

#define weapon_fire 
{if instance_exists(self)
	weapon_post(4,-4,4);
	{with(instance_create(x,y,Bullet1)){
	sound_play(global.sound);
	team = other.team;
	damage = 5;
	creator = other;
	sprite_index = global.shot;
	spr_dead = global.hit;
	direction = other.gunangle + random_range(-17,17) ;
	image_angle = direction;
	speed = 19;}}
	}