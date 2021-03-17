import pyodbc
import configparser
from csv import DictReader

from schema import db, Movies

db.connect()

with open('../../Data/ml-25m/movies.csv', 'r') as movies_csv:
    csv_dict_reader = DictReader(movies_csv)
    count = 0
    total = csv_dict_reader.line_num

    with db.atomic():
        for row in csv_dict_reader:
            if count % 1000 == 0:
                print(count)
            count += 1
            movie = Movies.create(id=row['movieId'], name=row["title"])

    