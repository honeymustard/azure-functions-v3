import sys
import json
import requests

# pip install requests
#
# run a function
# python run.py HorseTimer
#
# run a function and post some json
# python run.py HorseTimer "{ \"key\": \"value\" }"

print("")
args = sys.argv

if len(args) == 1 or len(args) > 3:
  print(args)
  print(' usage: python timer.py [function] [json]')
else:
  name = args[1]
  response = ''
  url = f"http://localhost:7071/admin/functions/{name}"

  print(f" function: {name}")

  if len(args) == 3:
    print(f" payload: {args[2]}")
    response = requests.post(url, json=json.loads(args[2]))
  else:
    response = requests.post(url, json={})

  print(f" response: {response.status_code}")