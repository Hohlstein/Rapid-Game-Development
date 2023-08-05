using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoBox_Manager : MonoBehaviour
{
    public infoBox_SizeManager size_manager;
    public TMP_Manager title_TMP;
    public TMP_Manager body_TMP;
    public InfoBox_Animation animation;
    public BalancingData BalancingData;

    private string scene;
    private string title;
    private string body;
    private bool prepared = false;

    private enum sizes
    {
        large,
        medium,
        small
    }
    private sizes size;

    public void VoidOKPressed(){
        animation.FadeDownWithDestroy(gameObject);
    }

    public void Prepare(string input){
        scene = input;
        transform.localPosition = new Vector3(0f,0f,0f);
        loadInfo(scene);
        if (prepared == true)
        {
            if (animation != null){
                animation.FadeUp();
            }
        }
        else{
            Destroy(gameObject);
        }
    }

    private void loadInfo(string scene){
        if (scene == "HireList"){
            title = "Hire Employees";
            body = "It's time to choose your employees. You must make a choice of exactly 4 people who you think will cover the aspects of game creation the best.";
            size = sizes.small;
            prepared = true;
        }
        if (scene == "Chat"){
            title = "Chat";
            body = "It's the first week of working on your game! Chat with your employees to get insights into their progress and be notified of any problems.";
            size = sizes.medium;
            prepared = true;
        }
        if (scene == "Arbeitsteilung"){
            title = "Give out tasks";
            body = "Now that your employees are ready to begin their work week, you need to assign tasks to each of them. Be mindful of the number of hours they agreed to: You can give them some overtime, but overdoing it might cause burnout.";
            size = sizes.large;
            prepared = true;
        }
        if (scene == "MiniGamePreLobby"){
            title = "Minigame";
            body = "The game's progress depends on the efficiency of your employees. Finishing a minigame quickly will increase the overall productivity for the week within the minigame's category, so do your best!";
            size = sizes.medium;
            prepared = true;
        }
    }

    void Update(){
        if (prepared){
            if (title_TMP != null && body_TMP != null && size_manager != null && scene != null){                
                title_TMP.SetText(title);
                body_TMP.SetText(body);
                if (size == sizes.large){
                    size_manager.SetLarge();
                }
                if (size == sizes.medium){
                    size_manager.SetMedium();
                }
                if (size == sizes.small){
                    size_manager.SetSmall();
                }
            }
        }
    }
}
