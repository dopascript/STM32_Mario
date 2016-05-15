#ifndef GAME_H
#define GAME_H

#include "draw.h"
#include "controler.h"

typedef struct
{
	int32_t worldOffsetX;
	int32_t worldOffsetY;

	uint16_t marioX;
	uint16_t marioY;
	int16_t marioSpeedX;
	int16_t marioSpeedY;

	uint8_t state;

	int32_t ticks;
} GameState;

GameState sGameState;

void Game_Init(void);
void Game_Update(void);

#endif
