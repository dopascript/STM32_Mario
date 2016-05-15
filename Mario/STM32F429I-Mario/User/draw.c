#include "draw.h"
#include "image.h"
#include "level.h"
#include <string.h>

uint16_t* currentBuffer;
uint16_t* superBackGround;
uint32_t superBackGroundWidth;
uint32_t superBackGroundHeight;
uint32_t screenWidth = 320;
uint32_t screenHeight = 240;

void DrawBackground(uint16_t x, uint16_t y)
{
	uint32_t line = 0;
	for (line = 0; line < screenWidth; line++)
	{
	  memcpy(currentBuffer + (line * screenHeight),
			 superBackGround + ((superBackGroundHeight * (x + line)) + y),
			 screenHeight * 2);
	}
}

void DrawInSuperBackground(const uint16_t* img, uint32_t width, uint32_t height, uint32_t fromX, uint32_t fromY, uint32_t toX, uint32_t toY)
{
	uint32_t column = 0;
	for (column = 0; column < width; column++)
	{
		for(int y = 0;y < height;y++)
		{
			if(*(img + ((column + fromX) * Tiles_height) + fromY + y) != 2016)
			{
				*(superBackGround + (((column + toX) * superBackGroundHeight) + (screenHeight - 16 - toY) + y)) = *(img + ((column + fromX) * Tiles_height) + fromY + y);
			}
		}
	}
}

void DrawLevel(void)
{
	superBackGroundWidth = levelWidth * 16;
	superBackGroundHeight = levelHeight * 16;
	uint16_t x, y;
	uint16_t value;
	uint32_t total = levelHeight * levelWidth * 16 * 16;
	uint32_t i;

	for(i = 0;i < total;i++)
	{
		superBackGround[i] = 34429;
	}

	for(y = 0;y < levelHeight;y++)
	{
		for(x = 0;x < levelWidth;x++)
		{
			value = levelTile[y * levelWidth + x];
			if(value != 0)
			{
				DrawInSuperBackground(Tiles, 16, 16, (value - 1) * 16, 0, ((uint32_t)x) * 16, ((uint32_t)y) * 16);
			}
		}
	}
}

void drawSprite(int position_x, int position_y)
{
	for(int x = 0;x < 16;x++)
	{
		for(int y = 0;y < 16;y++)
		{
			if(*(Sprites + x * 16 + y) != 2016)
			{
				currentBuffer[((position_x + x) * screenHeight) + (screenHeight - (position_y - 16 + y))] = Sprites[x * 16 + y];
			}
		}
	}
}
