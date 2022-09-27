using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class InteractionEvents : MonoBehaviour
{
    private TextMeshPro _messages = new();

    private List<GameObject> _images = new List<GameObject>();
    private List<string> _imageNames = new List<string>();
    private int _currentImage = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("------------- START -------------");

        try
        {
            _images.Add(GameObject.Find("MacularDegeneration0"));
            //_images.Add(GameObject.Find("MacularDegeneration1"));
            //_images.Add(GameObject.Find("MacularDegeneration2"));
            _images.Add(GameObject.Find("MacularDegeneration3"));
            _images.Add(GameObject.Find("MacularDegeneration4"));
            _images.Add(GameObject.Find("MacularDegeneration5"));
            _images.Add(GameObject.Find("MacularDegeneration6"));
            //_images.Add(GameObject.Find("TunnelVision1"));
            _images.Add(GameObject.Find("TunnelVision2"));
            _images.Add(GameObject.Find("TunnelVision3"));
            _images.Add(GameObject.Find("TunnelVision4"));

            _imageNames.Add("Clear");
            //_imageNames.Add("Macular Degeneration 1");
            //_imageNames.Add("Macular Degeneration 2");
            _imageNames.Add("Macular Degeneration 1");
            _imageNames.Add("Macular Degeneration 2");
            _imageNames.Add("Macular Degeneration 3");
            _imageNames.Add("Macular Degeneration 4");
            _imageNames.Add("Tunnel Vision 1");
            _imageNames.Add("Tunnel Vision 2");
            _imageNames.Add("Tunnel Vision 3");
            //_imageNames.Add("Tunnel Vision 4");

            //--- Get the text message component so we can write messages to it!
            _messages = GameObject.Find("DisplayMessages").GetComponent<TextMeshPro>();
            if (_messages != null)
            {
                //_messages.text = $"DEVELOPMENT VERSION {_images.Count()}";
                //_messages.text = $"DEVELOPMENT VERSION ({_currentImage + 1}/{_images.Count()})";

                HideAllImages();
                ShowImage(_currentImage);
            }
            else
            {
                Debug.Log("Component not found!");
            }
        }
        catch (System.Exception exception)
        {
            _messages.text = exception.Message;
            Debug.Log(exception.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //--- Right Controller
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch) || OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            Debug.Log("------------- A -------------");
            _currentImage -= 1;
            if (_currentImage < 0) _currentImage = 0;
            //_messages.text = $"{_currentImage + 1}/{_images.Count()}";

            HideAllImages();
            ShowImage(_currentImage);
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) || OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch))
        {
            Debug.Log("------------- B -------------");
            _currentImage += 1;
            if (_currentImage >= _images.Count()) _currentImage = 0;
            //_messages.text = $"{_currentImage + 1}/{_images.Count()}";

            HideAllImages();
            ShowImage(_currentImage);
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            Debug.Log("------------- Trigger -------------");
            _currentImage = 0;
            //_messages.text = $"{_currentImage + 1}/{_images.Count()}";

            HideAllImages();
            ShowImage(_currentImage);
        }
    }

    private void HideAllImages()
    {
        foreach (var image in _images)
        {
            image.SetActive(false);
        }
    }

    private void ShowImage(int i)
    {
        _images[i].SetActive(true);
        _messages.text = _imageNames[i];
    }
}