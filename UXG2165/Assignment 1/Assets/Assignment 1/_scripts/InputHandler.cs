using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment1
{
    public class InputHandler : MonoBehaviour
    {
        private InputReceiver activeReceiver;

        private Dictionary<InputType, KeyCode> inputList;

        public void Initialize()
        {
            //make list of input keys (useful for keybinding)
            inputList = new Dictionary<InputType, KeyCode>();
            inputList.Add(InputType.YES, KeyCode.Y);
            inputList.Add(InputType.NO, KeyCode.N);
        }

        public void SetInputReceiver(InputReceiver inputReceiver)
        {
            //set current input receiver (to control 1 thing at a time)
            activeReceiver = inputReceiver;
        }

        // Update is called once per frame
        void Update()
        {
            //detect key input every frame

            //TASK 1d: Get input keys
            //Without using Unity Input Manager, detect keyboard input for Yes and No responses
            //and call the DoYesAction and DoNoAction functions respectively in activeReceiver.
            //The input should be detected when the key is pressed down.
            //You may retrieve the keycodes assigned for Yes and No input from inputList.
            //TASK 1d START
            if (Input.GetKeyDown(inputList[InputType.YES])) {
                activeReceiver.DoYesAction();
            }else if (Input.GetKeyDown(inputList[InputType.NO])) {
                activeReceiver.DoNoAction();
            }
            //TASK 1d END

            //TASK 1e: Yes and No Actions (open-ended question)
            //Answer the following questions within the comment below:
            //activeReceiver is an InputReceiver interface object. 
            //Apart from PlayerMovement, what other class is an InputReceiver?
            //What do DoYesAction and DoNoAction do in that class?
            //TASK 1e START

            /*Answer: 
             * GameOverMenuScript
             * Yes Action: Start game again
             * No Action: Quit game
             *      If in editor mode, stop playing the game
             *      If not in editor mode, exit the application
             */

            //TASK 1e END
        }

        void FixedUpdate()
        {
            //TASK 1a: Get movement direction
            //Using Unity Input Manager (Edit -> Project Settings -> Input Manager), 
            //without changing default values in Input Manager,
            //get the values of the Horizontal and Vertical axes (WASD and arrow keys by default)
            //and set them to moveDir vector as x and y values.
            //TASK 1a START

            Vector2 moveDir = Vector3.zero;
            moveDir.x = Input.GetAxis("Horizontal");
            moveDir.y = Input.GetAxis("Vertical");
            //TASK 1a END

            //apply move
            activeReceiver.DoMoveDir(moveDir);
        }
    }

    //enum for input keys
    public enum InputType
    {
        YES,
        NO
    }

    //interface for all input receivers
    public interface InputReceiver
    {
        void DoMoveDir(Vector2 aDir); //for movement controls
        void DoYesAction(); //yes option
        void DoNoAction(); //no option
    }
}