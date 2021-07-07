using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUI : MonoBehaviour
{

    public static HUI instance;

    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Triangle's first edge
    /// </summary>
    /// <param name="triangles"></param>
    /// <returns></returns>
    public string SetFirstEdgeText(Triangles triangles)
    {
        return triangles.firstEdge.ToString();
    }

    /// <summary>
    /// Triangle's second edge
    /// </summary>
    /// <param name="triangles"></param>
    /// <returns></returns>
    public string SetSecondEdgeText(Triangles triangles)
    {
        SliderMinMax(triangles.secondEdge);
        return triangles.secondEdge.ToString();
    }

    //Assign the slider min-max values according to edges
    void SliderMinMax(int edge)
    {
        GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>().minValue = edge;
        GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>().maxValue = 2 * edge;
    }

    public void AssignShootPowerText()
    {
        GameObject.FindGameObjectWithTag("Shoot").GetComponentInChildren<Text>().text = "Shoot: " + AssingnShootPower();
    }

    //Answer for hypotenuse
    void Answer(int hypotenuse)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("Attack");
        HController.instance.OnSelectingHypotenuse(hypotenuse);
    }

    public void AssignAnswer()
    {
        GameObject.FindGameObjectWithTag("Shoot").GetComponent<Button>().onClick.AddListener(() => Answer(AssingnShootPower()));
    }

    int AssingnShootPower()
    {
        return (int)GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>().value;
    }
}
