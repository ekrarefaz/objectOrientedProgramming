from time import sleep
from clock import Clock


def main():
    clock = Clock()
    while True:
        clock.tick()
        print(clock.time)
        sleep(0.5)
 
class Counter(object):

    def __init__(self, name: str):
        self._count = 0
        self._name = name

    # Methods
    def increment(self):
        self._count += 1

    def reset(self):
        self._count = 0

    # Properties
    @property
    def name(self) -> str:
        return self._name

    @name.setter
    def name(self, name):
        self._name = name

    @property
    def ticks(self) -> int:
        return self._count

from counter import Counter


class Clock(object):

    def __init__(self):
        self._seconds = Counter("Seconds")
        self._minutes = Counter("Minutes")
        self._hours = Counter("Hours")

    @property
    def time(self) -> str:
        return '{0:02d}:{1:02d}:{2:02d}'.format(self._hours.ticks, self._minutes.ticks, self._seconds.ticks)

    def tick(self) -> None:
        if (self._seconds.ticks != 59):
            self._seconds.increment()
        else:
            self._seconds.reset()
            if (self._minutes.ticks != 59):
                self._minutes.increment()
            else:
                self._minutes.reset()
                if (self._hours.ticks != 23):
                    self._hours.increment()
                else:
                    self._seconds.reset()
                    self._minutes.reset()
                    self._hours.reset()
                    
if __name__ == '__main__':
    main()