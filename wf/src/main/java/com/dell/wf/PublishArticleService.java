package com.dell.wf;

import org.flowable.engine.delegate.DelegateExecution;
import org.flowable.engine.delegate.JavaDelegate;
import org.springframework.stereotype.Service;

@Service
public class PublishArticleService implements JavaDelegate {
    public void execute(DelegateExecution execution) {
        System.out.println("Publishing the approved article.");
    }
}
