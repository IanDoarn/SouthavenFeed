import json

class Query:

    def __init__(self, cursor, query_string, file_name):
        self.cursor = cursor
        self.query_string = query_string
        self.headers = None
        self.result = None
        self.file_name = file_name

    def execute(self):
        data = self.cursor.execute(self.query_string)
        self.headers = tuple(i[0] for i in self.cursor.description)
        self.result = [row for row in data]

    def fresults(self):
        d = []
        for row in self.result:
            d.append({i[0]: i[1]  for i in list(zip(self.headers, row))})
        return d

    def write(self):
        with open(self.file_name, 'w')as jf:
            json.dump(self.fresults(), jf, ensure_ascii=True, indent=4)