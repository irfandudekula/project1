using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidesScript : MonoBehaviour
{
    public GameObject nextBtn;
    public GameObject prevBtn;
    public GameObject VideoBtn, SlideBtn, ExpBtn, firstSlide;
    public GameObject[] slides;
    public GameObject[] ExpData;
    public GameObject[] Videos;
    public GameObject[] VidPlayButtons;
    private int counter = 0, s1 = 0, v1 = 0, e1 = 0;

    void Start()
    {
        StopVideo();
        foreach (GameObject s in slides)
            s.SetActive(false);
        foreach (GameObject e in ExpData)
            e.SetActive(false);
        StopVideo();
        prevBtn.SetActive(false);
        nextBtn.SetActive(false);
        firstSlide.SetActive(true);
       
    }

    public void Experiment()
    {
        s1 = 0;
        v1 = 0;
        e1 = 1;
        firstSlide.SetActive(false);
        SlideBtn.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        VideoBtn.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        ExpBtn.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
        StopVideo();
        foreach (GameObject s in slides)
            s.SetActive(false);
        nextBtn.SetActive(true);
        counter = -1;
        next();
    }

    public void slide()
    {
        s1 = 1;
        v1 = 0;
        e1 = 0;
        StopVideo();
        firstSlide.SetActive(false);
        foreach (GameObject e in ExpData)
            e.SetActive(false);
        SlideBtn.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
        VideoBtn.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        ExpBtn.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        nextBtn.SetActive(true);
        counter = -1;
        next();
    }

    public void video()
    {
        v1 = 1;
        s1 = 0;
        e1 = 0;
        foreach (GameObject s in slides)
            s.SetActive(false);
        foreach (GameObject e in ExpData)
            e.SetActive(false);
        StopVideo();
        firstSlide.SetActive(false);
        VideoBtn.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
        SlideBtn.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        ExpBtn.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        nextBtn.SetActive(true);
        counter = -1;
        next();
    }

    public void next()
    {
        if (s1 == 1)
        {
            checkNxt(slides.Length);
            DisplayDataIn(slides);           
        }

        if (v1 == 1)
        {
            checkNxt(Videos.Length);
            DisplayVideoData();
        }

        if (e1 == 1)
        {
            checkNxt(ExpData.Length);
            DisplayDataIn(ExpData);
        }
    }

    public void prev()
    {
        if (s1 == 1)
        {
            checkPrev(slides.Length);
            DisplayDataIn(slides);       
        }

        if (v1 == 1)
        {
            checkPrev(Videos.Length);
            DisplayVideoData();
        }

        if (e1 == 1)
        {
            checkPrev(ExpData.Length);
            DisplayDataIn(ExpData);      
        }
    }

    private void checkNxt(int size)
    {
        counter++;
        if (counter >= size)
            counter -= 1;
        checkBtns(size);
    }

    private void checkPrev(int size)
    {
        counter--;
        if (counter < 0)
            counter = 0;
        checkBtns(size);
    }

    private void checkBtns(int len)
    {
    if (counter <= 0)
        prevBtn.SetActive(false);
    else
        prevBtn.SetActive(true);

    if (counter >= len - 1)
        nextBtn.SetActive(false);
    else
        nextBtn.SetActive(true);
    }

    private void StopVideo()
    {
        foreach (GameObject VidPlayBtn in VidPlayButtons)
            VidPlayBtn.SetActive(false);
        foreach (GameObject v in Videos)
            v.SetActive(false);
        Videos[0].SetActive(true);
        VidPlayButtons[0].SetActive(false);

    }

    private void DisplayDataIn(GameObject[] data)
    {
        foreach (GameObject d in data)
        {
            if (d == data[counter])
                d.SetActive(true);
            else
                d.SetActive(false);
        }
    }

    private void DisplayVideoData()
    {
        foreach (GameObject VidPlayBtn in VidPlayButtons)
        {
            VidPlayBtn.SetActive(false);
        }
        foreach (GameObject v in Videos)
        {
            if (v == Videos[counter])
            {
                v.SetActive(true);
                VidPlayButtons[counter].SetActive(true);
            }
            else
                v.SetActive(false);
        }
    }

}