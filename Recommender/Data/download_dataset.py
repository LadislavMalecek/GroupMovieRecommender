import urllib.request
import configparser
import os

from zipfile import ZipFile


config = configparser.ConfigParser()
config.read('../conf.ini')

url = str(config['Dataset']['Url'])
data_path = config['Project']['Path'] + 'Data/'
print('Data directory: ' + data_path)
print('Downloading dataset...')
print(url)

urllib.request.urlretrieve(url, data_path + 'data.zip')

print('Dataset downloaded, unzipping...')
with ZipFile(data_path + 'data.zip', 'r') as zipObj:
   # Extract all the contents of zip file in current directory
   zipObj.extractall(data_path)

os.remove(data_path + 'data.zip')