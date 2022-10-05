using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    PlayerAction inputAction;

    static Queue<iCommand> commandBuffer;

    static List<iCommand> commandHistory;

    static int counter;

    private void Start()
    {
        commandBuffer = new Queue<iCommand>();
        commandHistory = new List<iCommand>();

        inputAction = PlayerInputController.controller.inputAction;

        inputAction.Editor.Undo.performed += cntxt => UndoCommand();
<<<<<<< Updated upstream
        inputAction.Editor.Redo.performed += cntxt => RedoCommand();
    }

    public static void AddCommand(iCommand command)
    {
        while(commandHistory.Count > counter)
        {
            commandHistory.RemoveAt(counter);
        }

        commandBuffer.Enqueue(command);

        
=======
        inputAction.Editor.Undo.performed += cntxt => RedoCommand();
>>>>>>> Stashed changes
    }

    public static void addCommand(iCommand command)
    {
<<<<<<< Updated upstream
        if(commandBuffer.Count <= 0)
        {
            if(counter > 0)
            {
                counter--;
                commandHistory[counter].Undo();
            }
        }
    }

    private void RedoCommand()
    {

    }

    private void Update()
    {
        if(commandBuffer.Count > 0)
        {
            iCommand c = commandBuffer.Dequeue();
            c.Execute();

            commandHistory.Add(c);

            counter++;

            Debug.Log("Command history length is: " + commandHistory.Count);
=======
        while(commandHistory.Count > counter)
        {
            commandHistory.RemoveAt(counter);
        }

        commandBuffer.Enqueue(command);
    }

    public void UndoCommand()
    {
        if(commandBuffer.Count <= 0)
        {
            if(counter > 0)
            {
                counter--;
                commandHistory[counter].Undo();
            }
        }
    }

    public void RedoCommand()
    {

    }


    private void Update()
    {
        //go through each value in commandBuffer
        if(commandBuffer.Count > 0)
        {
            iCommand c = commandBuffer.Dequeue();
            c.Execute();

            commandHistory.Add(c);
            counter++;
            Debug.Log("Command History length: " + commandHistory.Count);
>>>>>>> Stashed changes
        }
    }

}
