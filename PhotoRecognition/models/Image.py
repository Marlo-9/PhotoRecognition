#from models import Whale
import skimage.io
import cv2 as cv

class Image:
    def __init__(self, imagePath, maskPath):
        self.image = skimage.io.imread(imagePath)
        self.mask = skimage.io.imread(maskPath)

        sift = cv.SIFT_create()
        self.kp, self.des = sift.detectAndCompute(self.image, self.mask)

    def toArray(self):
        return self.image.tolist()

    def getKeyPointAsArray(self):
        kpArr = []
        kpArr.append([{'x': k.pt[0],'y': k.pt[1],'angle': k.angle,'octave': k.octave,'response': k.response,'size': k.size} for k in self.kp])

        return kpArr

    def getDescriptorsAsArray(self):
        desArr = []
        
        if(self.des is not None):
            desArr.append(str(d) for d in self.des)
        
        return desArr