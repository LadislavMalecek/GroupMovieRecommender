from peewee import Model, SqliteDatabase, TextField, DateField, IntegerField
import configparser


config = configparser.ConfigParser()
config.read('../conf.ini')

# db = SqliteDatabase(config['Database']['Filepath'])
db = SqliteDatabase(config['Project']['Path'] + config['Database']['Filepath'])

class BaseTable(Model):
    class Meta:
        database = db

class Movies(BaseTable):
    id = IntegerField(null=False)
    name = TextField(null=False, index=True)

    class Meta:
        database = db
        table_name = "Movies"