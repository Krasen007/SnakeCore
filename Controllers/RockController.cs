/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Krasen Ivanov. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace SnakeCore.Controllers
{
    using System;
    using SnakeCore.Models;
    using SnakeCore.Tools;

    public class RockController
    {
        private readonly Random random;

        public RockController()
        {
            this.random = new Random();
        }

        public void SpawnRocks(Snake snake, Rock rock)
        {                        
            do
            {
                rock.Position.X = this.random.Next(0, Constants.PlayWidth);
                rock.Position.Y = this.random.Next(0, Constants.PlayHeigth);
            }
            while (this.CollidesWithElements(snake, rock));
        }

        public bool CollidesWithElements(Snake snake, Rock rock)
        {
            for (int i = 0; i < snake.SnakeElements.Count; i++)
            {
                if (snake.SnakeElements[i].IsEqualTo(rock.Position))
                {
                    return true;
                }
            }

            return false;
        }
    }
}