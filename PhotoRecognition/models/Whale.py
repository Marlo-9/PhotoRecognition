import pickle
import numpy as np

class Whale(object):
    id: int = None
    kps = None
    dess = None
    matchesCount = 0
    def __init__(self, id) -> None:
        self.id = id
        self.kps = []
        self.dess = []

    def __getstate__(self):
        return list(self.dess)

    def __setstate__(self, state):
        self.dess = state

    def addKeyPoints(self, keypoints):
        for kp in keypoints:
            for i in kp:
                self.kps.append(i)
        
    def addDescriptors(self, descriptors):
        if (descriptors is not None):
            self.dess.append(descriptors)
            pass
