#ifndef DRAW_H
#define DRAW_H

#include "stm32f429i_discovery.h"

extern uint16_t* currentBuffer;
extern uint16_t* superBackGround;
extern uint32_t superBackGroundWidth;
extern uint32_t superBackGroundHeight;
extern uint32_t screenWidth;
extern uint32_t screenHeight;

void DrawBackground(uint16_t x, uint16_t y);
void DrawInSuperBackground(const uint16_t* img, uint32_t width, uint32_t height, uint32_t fromX, uint32_t fromY, uint32_t toX, uint32_t toY);
void DrawLevel(void);
void drawSprite(int position_x, int position_y);

#endif
