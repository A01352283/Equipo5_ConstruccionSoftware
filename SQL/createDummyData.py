import names
import random

#Andres: progress, inventory, sections, questions, scores

#Creates n number of dummy data for the user_game table
#Table structure: User_id, user_name, email, date_joined
def createGameUser(numData):
    dataToPrint = ""

    dataToPrint += "INSERT INTO game_user(user_id, user_name, email, date_joined)"
    dataToPrint += "\nVALUES\n"

    #Create all except the last entry
    for i in range (1, numData):
        name = names.get_first_name()

        dataToPrint += "    (" + str(i) + ", '" + name + "', '" + name + str(i + 1) + "@mail.com', " + "'2022-04-14'), \n"

    #Create the last entry
    name = names.get_first_name()

    dataToPrint += "    (" + str(i + 1) + ", '" + name + "', '" + name + str(i+1) + "@mail.com', " + "'2022-04-14');"    

    return dataToPrint


#Creates n number of dummy data for the progress table
#Table structure: progress_id, sections_id, inventory_id, score_id
def createProgress(numData):
    dataToPrint = ""

    dataToPrint += "INSERT INTO progress(progress_id, sections_id, inventory_id, score_id)"
    dataToPrint += "\nVALUES\n"

    #Create all except the last entry
    for i in range (1, numData):
        currentID = str(i)
        dataToPrint += "    (" + currentID + ", " + currentID + ", " + currentID + ", " + currentID + "), \n"

    #Create the last entry
    currentID = str(i + 1)
    dataToPrint += "    (" + currentID + ", " + currentID + ", " + currentID + ", " + currentID + ");"

    return dataToPrint

#Creates n number of dummy data for the inventory table
#Table structure: inventory_id, collected_instrument, instruments_hub, instruments_island1, instruments_island2
def createInventory(numData):
    dataToPrint = ""

    dataToPrint += "INSERT INTO inventory(inventory_id, collected_instrument, instruments_hub, instruments_island1, instruments_island2)"
    dataToPrint += "\nVALUES\n"

    #Create all except the last entry
    for i in range (1, numData):
        currentID = str(i)
        instHub = random.randrange(0, 3)
        inst1 = random.randrange(0, 3)
        inst2 = random.randrange(0, 3)
        colInst = inst1 + inst2 + instHub

        dataToPrint += "    (" + currentID + ", " + str(colInst) + ", " + str(instHub) + ", " + str(inst1) + ", " + str(inst2) + "), \n"

    #Create the last entry
    currentID = str(i + 1)
    dataToPrint += "    (" + currentID + ", " + str(colInst) + ", " + str(instHub) + ", " + str(inst1) + ", " + str(inst2) + ");"

    return dataToPrint

#Creates n number of dummy data for the questions table
#Table structure: question_id, question, cor_answer, answer_2, answer_3, answer_4
def createQuestions(numData):
    dataToPrint = ""

    dataToPrint += "INSERT INTO questions(question_id, question, cor_answer, answer_2, answer_3, answer_4)"
    dataToPrint += "\nVALUES\n"

    #Create all except the last entry
    for i in range (1, numData):
        currentID = str(i)

        dataToPrint += "    (" + currentID + ", " + random.choice(["This?", "That?,", "What?"]) + ", " + "a" + ", " + "b" + ", " + "c" + ", d" + "), \n"

    #Create the last entry
    currentID = str(i + 1)
    dataToPrint += "    (" + currentID + ", " + random.choice(["This?", "That?,", "What?"]) + ", " + "a" + ", " + "b" + ", " + "c" + ", d" + ");"

    return dataToPrint

#Creates n number of dummy data for the scores table
#Table structure: score_id, memory_id, trivia_id, rhythm_id, memorysounds_id
def createScore(numData):
    dataToPrint = ""

    dataToPrint += "INSERT INTO scorea(score_id, memory_id, trivia_id, rhythm_id, memorysounds_id)"
    dataToPrint += "\nVALUES\n"

    #Create all except the last entry
    for i in range (1, numData):
        currentID = str(i)
        dataToPrint += "    (" + currentID + ", " + currentID + ", " + currentID + ", " + currentID + ", " + currentID + "), \n"

    #Create the last entry
    currentID = str(i + 1)
    dataToPrint += "    (" + currentID + ", " + currentID + ", " + currentID + ", " + currentID + ", " + currentID + ");"

    return dataToPrint

def main():    
    currentData = createScore(20)

    with open('dummyDataPlaceHolder.txt', 'w') as f:
        for line in currentData:
            f.write(line)

main()