# Mandelbrot Set by KuttaBoi

import numpy as np
import cv2

frameWidth = 700
frameHeight = 500

maxIterations = 100

img = np.zeros([frameHeight, frameWidth])


def mandelbrot(zx, zy):

    z = np.complex(0, 0)
    zn = np.complex(zx, zy)

    for b in range(maxIterations):
        z = np.square(z) + zn
        if np.abs(z) > 2:
            return b/maxIterations
    return 0


# Calculate Mandelbrot Set
origX = frameWidth/2

origY = frameHeight/2

scaleFactor = 200
offset = (-0.5, 0)

for i in range(frameWidth-1):
    for j in range(frameHeight-1):

        x = (i - origX)/scaleFactor + offset[0]
        y = (j - origY)/scaleFactor + offset[1]

        img[j, i] = mandelbrot(x, y)


while True:
    cv2.imshow("Mandelbrot", img)
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break
