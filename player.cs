using System;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    public TextMeshPro coinTextMesh;
    public float moveSpeed;
    public List<Coin> coinList;
    public List<Transform> buildingTransformList;
    
    private int coinAmount;
    
    private void Update() {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.position += new Vector3(0, +1, 0) * moveSpeed;
        }
        
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            transform.position += new Vector3(0, -1, 0) * moveSpeed;
        }
        
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.position += new Vector3(-1, 0, 0) * moveSpeed;
        }
        
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.position += new Vector3(+1, 0, 0) * moveSpeed;
        }
        
        HandleCoins();
        
        if(Input.GetKeyDown(KeyCode.Space)) {
            HandleBuildingInteraction();
        }
    }
    
    private void HandleCoins() {
        foreach(Coin coin in coinList) {
            if(coin != null) {
                float coinPickUpDistance = 1.5f;
                
                if(Vector3.Distance(transform.position, coin.transform.position) < coinPickUpDistance) {
                    AddCoin();
                    
                    coin.DestroySelf();
                }
            }
        }
    }
    
    private void HandleBuildingInteraction() {
        for(int i = 0; i < buildingTransformList.Count; i++) {
            Transform buildingTransform = buildingTransformList[i];
            float interactDistance = 2f;
            
            if(Vector3.Distance(transform.position, buildingTransform.position) < interactDistance) {
                switch(buildingTransform.name) {
                    case "Building_CoinX1":
                        AddCoin();
                        break;
                    case "Building_CoinX3":
                        AddCoin();
                        AddCoin();
                        AddCoin();
                        break;
                    default:
                        Debug.LogError("Unknown building!");
                        break;
                }
            }
        }
    }
    
    private void AddCoin() {
        coinAmount++;
        
        coinTextMesh.text = coinAmount.ToString();
    }
}
