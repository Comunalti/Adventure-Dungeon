#define init
global.sprite = sprite_add_weapon("GemHighLaserRifleModule.png", 5, 2);
global.shot = sprite_add("Laser Module Shot (Gem High).png",1,sprite_get_xoffset(sprLaser), sprite_get_yoffset(sprLaser));
global.sound = sound_add("Laser Module Shot (Gem High).ogg")
global.swap = sound_add("Module Swap.ogg")

#define weapon_name
	return "Gem High Laser Rifle Module";

#define weapon_type
	return 5;

#define weapon_area
	return 12;

#define weapon_cost
	return 1;

#define weapon_auto
	return true;

#define weapon_load 
	return weapon_get_load(wep_laser_rifle);

#define weapon_swap
	return global.swap;
	
#define weapon_sprt
	return global.sprite;

#define weapon_text
	return "@rGematized @wdestruction";

#define weapon_fire 
{if instance_exists(self)
	weapon_post(4,-4,4);
	{with(instance_create(x,y,Laser)){
	sound_play(global.sound);
	team = other.team;
	damage = 7;
	creator = other;
	alarm0 = 1;
	sprite_index = global.shot;
	direction = other.gunangle + random_range(-3,3) ;
	image_angle = direction;}}
	}