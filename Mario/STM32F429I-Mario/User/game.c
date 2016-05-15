#include "game.h"
#include "level.h"
#include <stdlib.h>

#define STATE_TITLE 0
#define STATE_GAME  1
#define STATE_DEATH 2

#define MAX_SPEED 20
#define SPEED_DIV 5

uint8_t GetCaseValue(int x, int y);
void GameInitForTitle(void);
void GameInitForGame(void);
void GameInitForDeath(void);
void UpdateForTitle(void);
void UpdateForGame(void);
void UpdateForDeath(void);
void Jump(void);
uint8_t MarioCollision(uint16_t x, uint16_t y);
uint8_t Collision(uint16_t x, uint16_t y);

void Game_Init(void)
{
	DrawLevel();
	GameInitForTitle();
}

void GameInitForTitle(void)
{
	sGameState.worldOffsetX = 0;
	sGameState.worldOffsetY = 0;

	sGameState.marioX = 10 * 16;
	sGameState.marioY = 2 * 16;

	sGameState.marioSpeedX = 0;
	sGameState.marioSpeedY = 0;

	sGameState.ticks = 0;

	sGameState.state = STATE_TITLE;
}

void GameInitForGame(void)
{
	sGameState.worldOffsetX = 0;
	sGameState.worldOffsetY = 0;

	sGameState.marioX = 2 * 16;
	sGameState.marioY = 1 * 16;

	sGameState.marioSpeedX = 0;
	sGameState.marioSpeedY = 0;

	sGameState.ticks = 0;

	sGameState.state = STATE_GAME;
}

void GameInitForDeath(void)
{
	sGameState.marioSpeedX = 0;
	sGameState.marioSpeedY = -10;

	sGameState.ticks = 0;

	sGameState.state = STATE_DEATH;
}

void Game_Update(void)
{
	switch(sGameState.state)
	{
	case STATE_TITLE:
		UpdateForTitle();
		break;
	case STATE_GAME:
		UpdateForGame();
		break;
	case STATE_DEATH:
		UpdateForDeath();
		break;
	}
	//Draw world
	sGameState.worldOffsetX = sGameState.marioX - (screenWidth / 2);
	if(sGameState.worldOffsetX < 0) sGameState.worldOffsetX = 0;
	if(sGameState.worldOffsetX > (superBackGroundWidth) - 320) sGameState.worldOffsetX = (superBackGroundWidth) - 320;
	DrawBackground(sGameState.worldOffsetX, sGameState.worldOffsetY);
	//Draw sprites
	drawSprite(sGameState.marioX - 8 - sGameState.worldOffsetX, sGameState.marioY);

	sGameState.ticks++;
}

inline void UpdateForTitle(void)
{
	uint8_t moveIteX;
	uint8_t moveIteY;
	uint8_t moveTotalIteX;
	uint8_t moveTotalIteY;
	int8_t incX;
	int8_t incY;

	if( ButtonsPressed[BUTTON_RIGHT] == 0 )
	{
		sGameState.marioSpeedX++;
	}

	else if( ButtonsPressed[BUTTON_LEFT] == 0 )
	{
		sGameState.marioSpeedX--;
	}
	else
	{
		if(sGameState.marioSpeedX < 0) { sGameState.marioSpeedX++; }
		else if(sGameState.marioSpeedX > 0) { sGameState.marioSpeedX--; }
	}
	if( ButtonsPressed[BUTTON_A] == 0 )
	{
		Jump();
	}
	sGameState.marioSpeedY++;

	moveIteX = 0;
	moveIteY = 0;
	moveTotalIteX = abs(sGameState.marioSpeedX / SPEED_DIV);
	moveTotalIteY = abs(sGameState.marioSpeedY / SPEED_DIV);
	incX = (sGameState.marioSpeedX > 0 ? 1 : -1);
	incY = (sGameState.marioSpeedY > 0 ? 1 : -1);

	int8_t doAgain;
	do
	{
		doAgain = 0;
		if(moveIteX < moveTotalIteX)
		{
			if(MarioCollision(sGameState.marioX + incX,sGameState.marioY) == 0)
			{
				sGameState.marioX += incX;
				moveIteX++;
				doAgain = 1;
			}
			else
			{
				sGameState.marioSpeedX = 0;
			}
		}
		if(moveIteY < moveTotalIteY)
		{
			if(MarioCollision(sGameState.marioX,sGameState.marioY + incY) == 0)
			{
				sGameState.marioY += incY;
				moveIteY++;
				doAgain = 1;
			}
			else
			{
				sGameState.marioSpeedY = 0;
			}
		}
	}while(doAgain == 1);

	if(sGameState.marioSpeedX > MAX_SPEED) { sGameState.marioSpeedX = MAX_SPEED; }
	if(sGameState.marioSpeedX < -MAX_SPEED) { sGameState.marioSpeedX = -MAX_SPEED; }
	if(sGameState.marioSpeedY > MAX_SPEED) { sGameState.marioSpeedY = MAX_SPEED; }
}

uint8_t MarioCollision(uint16_t x, uint16_t y)
{
	return Collision(x + 7, y - 2) + Collision(x + 7, y - 17) + Collision(x - 8, y - 2) + Collision(x - 8, y - 17);
}

uint8_t Collision(uint16_t x, uint16_t y)
{
	uint16_t iX = x / 16;
	uint16_t iY = y / 16;
	return levelTile[iY * levelWidth + iX];
}

inline void UpdateForGame(void)
{
	uint8_t moveIteX;
	uint8_t moveIteY;
	uint8_t moveTotalIteX;
	uint8_t moveTotalIteY;
	int8_t incX;
	int8_t incY;

	if( ButtonsPressed[BUTTON_RIGHT] == 0 )
	{
		sGameState.marioSpeedX++;
	}

	else if( ButtonsPressed[BUTTON_LEFT] == 0 )
	{
		sGameState.marioSpeedX--;
	}
	else
	{
		if(sGameState.marioSpeedX < 0) { sGameState.marioSpeedX++; }
		else if(sGameState.marioSpeedX > 0) { sGameState.marioSpeedX--; }
	}
	if( ButtonsPressed[BUTTON_A] == 0 && Collision(sGameState.marioX, sGameState.marioY + 1) != 0)
	{
		Jump();
	}
	sGameState.marioSpeedY++;

	moveIteX = 0;
	moveIteY = 0;
	moveTotalIteX = abs(sGameState.marioSpeedX / 3);
	moveTotalIteY = abs(sGameState.marioSpeedY / 3);
	incX = (sGameState.marioSpeedX > 0 ? 1 : -1);
	incY = (sGameState.marioSpeedY > 0 ? 1 : -1);

	int8_t doAgain;
	do
	{
		doAgain = 0;
		if(moveIteX < moveTotalIteX)
		{
			if(MarioCollision(sGameState.marioX + incX,sGameState.marioY) == 0)
			{
				sGameState.marioX += incX;
				moveIteX++;
				doAgain = 1;
			}
			else
			{
				sGameState.marioSpeedX = 0;
			}
		}
		if(moveIteY < moveTotalIteY)
		{
			if(MarioCollision(sGameState.marioX,sGameState.marioY + incY) == 0)
			{
				sGameState.marioY += incY;
				moveIteY++;
				doAgain = 1;
			}
			else
			{
				sGameState.marioSpeedY = 0;
			}
		}
	}while(doAgain == 1);

	if(sGameState.marioSpeedX > MAX_SPEED) { sGameState.marioSpeedX = MAX_SPEED; }
	if(sGameState.marioSpeedX < -MAX_SPEED) { sGameState.marioSpeedX = -MAX_SPEED; }
	if(sGameState.marioSpeedY > MAX_SPEED) { sGameState.marioSpeedY = MAX_SPEED; }
}

inline void UpdateForDeath(void)
{

}

inline void Jump(void)
{
	sGameState.marioSpeedY = -10;
}
