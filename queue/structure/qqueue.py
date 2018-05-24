class QQueue:

    def __init__(self):
        self.size = 0
        self.data = []

    def enqueue(self, item):
        self.data.append(item)
        self.size += 1

    def dequeue(self):
        if not self.is_empty():
            d = self.data.pop(0)
            self.size -= 1
            return d
        else:
            return None

    def is_empty(self):
        return self.size == 0

    def peek(self):
        import copy
        if not self.is_empty():
            return copy.deepcopy(self.data[0])
