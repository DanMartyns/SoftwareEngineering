import json

with open('ecg.txt','w') as ecg: 
    with open('ecg_3219.json') as json_file:  
        data = json.load(json_file)
        for d in data['stream']:
            ecg.write(d["values"]+"\n")
    json_file.close()
ecg.close()