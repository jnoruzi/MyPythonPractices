
photo_list = open("/home/javad/Programming/python/Self Practice/photolist.txt").read().split('\n')


for i in range(len(photo_list)):
    photo_list[i] += ", {}".format(i+1) # save original order

# Order by cityname and then by capture date
photo_list.sort(key=lambda x: (x.split(',')[1].strip(),x.split(',')[2].strip()))

j=0
city_name = ""
for i in range(len(photo_list)):
    # Reset Group Order Counter
    if city_name != photo_list[i].split(',')[1].strip():
        city_name = photo_list[i].split(',')[1].strip()
        city_cnt = sum(map(lambda x : x.split(',')[1].strip() == city_name, photo_list))
        j=1

    zero_num = str(j)
    for m in range(0,len(str(city_cnt)) - len(str(j))):
        zero_num = "0" + zero_num

    # Save new order and new file name
    photo_list[i] += ", {}, {}{}.{}".format(j,city_name,zero_num,photo_list[i].split(',')[0].split('.')[1])
    j += 1

# Order by Original Order
photo_list.sort(key=lambda x: int(x.split(',')[3].strip()))

str_result = ""
for x in photo_list:
    str_result += "{}\n".format(x.split(',')[5])

print(str_result)

